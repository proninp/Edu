package level.l009.lecture11;

import java.util.HashMap;
import java.util.HashSet;
import java.util.Map;
import java.util.Set;

public class Solution09 {
    public static void main(String[] args) {
        Map<String, Cat> map = createMap();
        Set<Cat> set = convertMapToSet(map);
        printCatSet(set);
    }

    public static Map<String, Cat> createMap() {
        Map<String, Cat> map = new HashMap<String, Cat>(10);
        map.put("01", new Cat("01"));
        map.put("02", new Cat("02"));
        map.put("03", new Cat("03"));
        map.put("04", new Cat("04"));
        map.put("05", new Cat("05"));
        map.put("06", new Cat("06"));
        map.put("07", new Cat("07"));
        map.put("08", new Cat("08"));
        map.put("09", new Cat("09"));
        map.put("10", new Cat("10"));
        return map;
    }

    public static Set<Cat> convertMapToSet(Map<String, Cat> map) {
        return new HashSet<>(map.values());
    }

    public static void printCatSet(Set<Cat> set) {
        for (Cat cat : set) {
            System.out.println(cat);
        }
    }

    public static class Cat {
        private String name;

        public Cat(String name) {
            this.name = name;
        }

        public String toString() {
            return "Cat " + this.name;
        }
    }
}
