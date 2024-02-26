package patterns.builder;

/**
 * The NutritionFacts class is immutable, and all parameter default values are
 * in one place. The builder’s setter methods return the builder itself so that invocations
 * can be chained, resulting in a fluent API. Here’s how the client code looks.
 */
public class BuilderUsage {
    public static void use() {
        NutritionFacts nutritionFacts = new NutritionFacts.Builder(240, 8)
                .calories(100)
                .sodium(35)
                .carbohydrate(27)
                .build();
    }
}
