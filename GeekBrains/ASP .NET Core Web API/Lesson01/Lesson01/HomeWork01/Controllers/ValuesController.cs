using Microsoft.AspNetCore.Mvc;

namespace HomeWork01.Controllers
{
    [Route("api/CrudExample")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ValuesHolder _valuesHolder;

        public ValuesController(ValuesHolder valueHolder)
        {
            _valuesHolder = valueHolder;
        }

        [HttpGet("list")]
        public IActionResult Get()
        {
            return Ok(_valuesHolder.Get());
        }

        [HttpGet("getJson")]
        public IEnumerable<string> GetJson()
        {
            return _valuesHolder.Values;
        }

        [HttpPost("create")]
        public IActionResult Create([FromQuery] string input)
        {
            _valuesHolder.Add(input);
            return Ok();
        }

        [HttpPost("createFromBatch")]
        public IActionResult CreateFromBatch([FromQuery] string input)
        {
            var inputArray = input.Split(",");
            _valuesHolder.Values.AddRange(inputArray);
            return Ok();
        }

        [HttpPut("update")]
        public IActionResult Update([FromQuery] string stringToUpdate, [FromQuery] string newValue)
        {
            for (int i = 0; i < _valuesHolder.Values.Count; i++)
            {
                if (_valuesHolder.Values[i] == stringToUpdate)
                    _valuesHolder.Values[i] = newValue;
            }
            return Ok();
        }

        [HttpDelete("delete")]
        public IActionResult Delete([FromQuery] string stringToDelete)
        {
            _valuesHolder.Values = _valuesHolder.Values.Where(x => x != stringToDelete).ToList();
            return Ok();
        }
    }
}
