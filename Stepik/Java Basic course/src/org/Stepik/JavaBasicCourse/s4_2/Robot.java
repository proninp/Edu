package org.Stepik.JavaBasicCourse.s4_2;

import org.Stepik.JavaBasicCourse.Direction;

public class Robot {
    private int x = 0;
    private int y = 0;
    private Direction direction = Direction.UP;

    public Direction getDirection() {
        return direction;
    }

    public int getX() {
        return x;
    }

    public int getY() {
        return y;
    }

    public void turnLeft() {
        System.out.println("������� ������ ������� �������");
        switch (direction) {
            case DOWN -> this.direction = Direction.RIGHT;
            case UP -> this.direction = Direction.LEFT;
            case LEFT -> this.direction = Direction.DOWN;
            case RIGHT -> this.direction = Direction.UP;
        }
    }

    public void turnRight() {
        System.out.println("������� �� ������� �������");
        switch (direction) {
            case DOWN -> this.direction = Direction.LEFT;
            case UP -> this.direction = Direction.RIGHT;
            case LEFT -> this.direction = Direction.UP;
            case RIGHT -> this.direction = Direction.DOWN;
        }
    }

    public void stepForward() {
        if (direction == Direction.DOWN) {
            System.out.println("����");
            this.y--;
        }

        if (direction == Direction.UP) {
            System.out.println("�����");
            this.y++;
        }

        if (direction == Direction.LEFT) {
            System.out.println("������");
            this.x--;
        }

        if (direction == Direction.RIGHT) {
            System.out.println("�������");
            this.x++;
        }
    }
    public void printPosition() {
        System.out.println("Current position: [X: " + this.x + "; Y: " + this.y + "]");
    }

}