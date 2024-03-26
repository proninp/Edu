package com.javarush.games.game2048;

import com.javarush.engine.cell.Color;
import com.javarush.engine.cell.Game;
import com.javarush.engine.cell.Key;

public class Game2048 extends Game {
    private static final int SIDE = 4;
    private  int[][] gameField = new int[SIDE][SIDE];

    @Override
    public void initialize() {
        setScreenSize(SIDE, SIDE);
        createGame();
        drawScene();
    }

    private void createGame() {
        createNewNumber();
        createNewNumber();
    }

    private void drawScene() {
        for (int i = 0; i < SIDE; i++) {
            for (int j = 0; j < SIDE; j++) {
                setCellColoredNumber(j, i, gameField[i][j]);
            }
        }
    }

    private void createNewNumber() {
        int rX;
        int rY;
        do {
            rX = getRandomNumber(SIDE);
            rY = getRandomNumber(SIDE);
        } while (gameField[rX][rY] != 0);
        gameField[rX][rY] = getRandomNumber(10) == 9 ? 4 : 2;
    }

    private void setCellColoredNumber(int x, int y, int value) {
        setCellValueEx(x, y, getColorByValue(value), value == 0 ? "" : String.valueOf(value));
    }

    private Color getColorByValue(int value) {
        switch (value) {
            case 2:
                return Color.GHOSTWHITE;
            case 4:
                return Color.WHITESMOKE;
            case 8:
                return Color.ANTIQUEWHITE;
            case 16:
                return Color.LIGHTYELLOW;
            case 32:
                return Color.LIGHTGOLDENRODYELLOW;
            case 64:
                return Color.GOLDENROD;
            case 128:
                return Color.LIGHTCORAL;
            case 256:
                return Color.ORANGE;
            case 512:
                return Color.ORANGERED;
            case 1024:
                return Color.RED;
            case 2048:
                return Color.DARKRED;
            default:
                return Color.LIGHTGREY;
        }
    }

    private boolean compressRow(int[] row) {
        boolean result = false;
        for (int i = 0, newRowIndex = 0; i < row.length; i++) {
            if (row[i] != 0) {
                if (i != newRowIndex) {
                    result = true;
                    int t = row[i];
                    row[i] = row[newRowIndex];
                    row[newRowIndex] = t;
                }
                newRowIndex++;
            }
        }
        return result;
    }

    private boolean mergeRow(int[] row) {
        boolean result = false;
        for (int i = 0; i < row.length - 1; i++) {
            if (row[i] != 0 && row[i] == row[i + 1]) {
                row[i] *= 2;
                row[i + 1] = 0;
                i++;
                result = true;
            }
        }
        return result;
    }

    @Override
    public void onKeyPress(Key key) {
        if (key == Key.LEFT) {
            moveLeft();
            drawScene();
        } else if (key == Key.RIGHT) {
            moveRight();
            drawScene();
        } else if (key == Key.UP) {
            moveUp();
            drawScene();
        } else if (key == Key.DOWN) {
            moveDown();
            drawScene();
        }
    }

    private void moveLeft() {
        boolean isDraw = false;
        for (int i = 0; i < gameField.length; i++) {
            boolean isCompress = compressRow(gameField[i]);
            boolean isMerge = mergeRow(gameField[i]);
            if (isMerge)
                compressRow(gameField[i]);
            if (isCompress || isMerge)
                isDraw = true;
        }
        if (isDraw) {
            createNewNumber();
        }
    }

    private void moveRight() {

    }

    private void moveUp() {

    }

    private void moveDown() {

    }

    private void rotateClockwise() {
        int len = gameField.length;
        for (int row = 0; row < len; row++) {
            for (int col = row; col < len; col++) {
                swap(row, col, col, row);
            }
        }
        for (int row = 0; row < len; row++) {
            for (int col = 0; col < len / 2; col++) {
                swap(row, col, row, len - 1 - col);
            }
        }
    }
    private void swap(int i, int j, int k, int l) {
        int t = gameField[i][j];
        gameField[i][j] = gameField[k][l];
        gameField[k][l] = t;

    }
}
