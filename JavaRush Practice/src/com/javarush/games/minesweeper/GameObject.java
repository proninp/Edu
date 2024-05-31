package com.javarush.games.minesweeper;

import java.util.ArrayList;
import java.util.List;

public class GameObject {
    public int x, y;
    public boolean isMine;
    public int countMineNeighbors;
    public boolean isOpen;
    public boolean isFlag;

    public GameObject(int x, int y/*, boolean isMine*/) {
        this.x = x;
        this.y = y;
        //this.isMine = isMine;
    }

    @Override
    public boolean equals(Object that) {
        if (this == that) return  true;
        if (that == null || getClass() != that.getClass()) return  false;
        GameObject gameObject = (GameObject) that;
        return this.x == gameObject.x && this.y == gameObject.y;
    }

    @Override
    public int hashCode() {
        int result = x + y;
        result += 31 * x;
        result += 29 * y;
        return  result;
    }
}
