package com.javarush.games.moonlander;

public class Rocket extends GameObject {
    private double speedY = 0;
    private double speedX = 0;
    private double boost = 0.05;
    private double slowdown = boost / 10;
    public Rocket(double x, double y) {

        super(x, y, ShapeMatrix.ROCKET);
    }

    public void move(boolean isUpPressed, boolean isLeftPressed, boolean isRightPressed) {
        if (!(isLeftPressed || isRightPressed)) {
            if (speedX >= -slowdown && speedX <= slowdown) {
                speedX = 0;
            } else if (speedX > slowdown) {
                speedX -= slowdown;
            } else if (speedX < -slowdown) {
                speedX += slowdown;
            }
        }
        if (isUpPressed) {
            speedY -= boost;
        } else {
            speedY += boost;
        }
        if (isLeftPressed) {
            speedX -= boost;
        }
        if (isRightPressed) {
            speedX += boost;
        }

        this.y += speedY;
        this.x += speedX;

        checkBorders();
    }

    private void checkBorders() {
        if (x < 0) {
            x = 0;
            speedX = 0;
        }
        if (x + width > MoonLanderGame.WIDTH) {
            x = MoonLanderGame.WIDTH - width;
            speedX = 0;
        }
        if (y < 0) {
            y = 0;
            speedY = 0;
        }
    }
}