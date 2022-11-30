import com.codewars.kyu6.*;
import com.codewars.kyu7.*;
import com.codewars.kyu5.*;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class Main {
    public static void main(String[] args) {
        //System.out.println(MeanSquareError.solution(new int[] {10, 20, 10, 2}, new int[] {10, 25, 5, -2}));
        PaginationHelper<Character> helper = new PaginationHelper(Arrays.asList('a', 'b', 'c', 'd', 'e', 'f'), 4);
        System.out.println(helper.pageCount()); //should == 2
        System.out.println(helper.itemCount()); //should == 6
        System.out.println(helper.pageItemCount(0)); //should == 4
        System.out.println(helper.pageItemCount(1)); // last page - should == 2
        System.out.println(helper.pageItemCount(2)); // should == -1 since the page is invalid

// pageIndex takes an item index and returns the page that it belongs on
        System.out.println(helper.pageIndex(5)); //should == 1 (zero based index)
        System.out.println(helper.pageIndex(2)); //should == 0
        System.out.println(helper.pageIndex(20)); //should == -1
        System.out.println(helper.pageIndex(-10)); //should == -1
    }
}