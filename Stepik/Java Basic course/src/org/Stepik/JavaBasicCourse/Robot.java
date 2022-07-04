package org.Stepik.JavaBasicCourse;

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
        System.out.println("Поворот против часовой стрелки");
        switch (direction) {
            case DOWN -> this.direction = Direction.RIGHT;
            case UP -> this.direction = Direction.LEFT;
            case LEFT -> this.direction = Direction.DOWN;
            case RIGHT -> this.direction = Direction.UP;
        }
    }

    public void turnRight() {
        System.out.println("поворот по часовой стрелке");
        switch (direction) {
            case DOWN -> this.direction = Direction.LEFT;
            case UP -> this.direction = Direction.RIGHT;
            case LEFT -> this.direction = Direction.UP;
            case RIGHT -> this.direction = Direction.DOWN;
        }
    }

    public void stepForward() {
        if (direction == Direction.DOWN) {
            System.out.println("вниз");
            this.y--;
        }

        if (direction == Direction.UP) {
            System.out.println("вверх");
            this.y++;
        }

        if (direction == Direction.LEFT) {
            System.out.println("налево");
            this.x--;
        }

        if (direction == Direction.RIGHT) {
            System.out.println("направо");
            this.x++;
        }
    }
    public void printPosition() {
        System.out.println("Current position: [X: " + this.x + "; Y: " + this.y + "]");
    }

}