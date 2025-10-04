package main.java.com.codewars.kyu6.reversePolishNotationCalculator;

import java.util.HashMap;
import java.util.Stack;
import java.util.function.BinaryOperator;

public class RpnCalculator {
    public double evaluate(String expr) {
        if (expr.isEmpty()) return 0;
        var stack = new Stack<Double>();
        stack.push(0d);
        var ops = new HashMap<Character, BinaryOperator<Double>>();
        ops.put('+', (a, b) -> a + b);
        ops.put('-', (a, b) -> b - a);
        ops.put('*', (a, b) -> a * b);
        ops.put('/', (a, b) -> b / a);
        for (var el : expr.trim().split("\\s+")) {
            if (ops.containsKey(el.charAt(0))) {
                stack.push(ops.get(el.charAt(0)).apply(stack.pop(), stack.pop()));
            } else {
                stack.push(Double.parseDouble(el));
            }
        }
        return stack.pop();
    }
}
