package com.javarush.games.minesweeper;

import com.javarush.engine.cell.*;

import java.util.ArrayList;
import java.util.List;

public class MinesweeperGame extends Game {
    private static final int SIDE = 9;
    private GameObject[][] gameField = new GameObject[SIDE][SIDE];
    private static final String MINE = "\uD83D\uDCA3";
    private static final String FLAG = "\uD83D\uDEA9";
    private static final Color CELL_COLOR = Color.ANTIQUEWHITE;
    private int countMinesOnField;
    private int countFlags;
    private int countClosedTiles = SIDE * SIDE;

    private int score;
    private boolean isGameStopped;
    @Override
    public void initialize() {
        setScreenSize(SIDE, SIDE);
        createGame();
    }
    private void createGame() {
        int chance = 10;
        for (int x = 0; x < SIDE; x++) {
            for (int y = 0; y < SIDE; y++) {
                boolean isMine = getRandomNumber(chance) == chance - 1;
                if (isMine)
                    countMinesOnField++;
                gameField[x][y] = new GameObject(y, x, isMine);
                setCellValue(x, y, "");
                setCellColor(x, y, CELL_COLOR);
            }
        }
        countFlags = countMinesOnField;
        countMineNeighbors();
    }
    private void countMineNeighbors() {
        List<GameObject> neighbors;
        for (int y = 0; y < SIDE; y++) {
            for (int x = 0; x < SIDE; x++) {
                if (gameField[y][x].isMine)
                    continue;
                neighbors = getNeighbors(gameField[y][x]);
                for (GameObject n : neighbors) {
                    if (gameField[n.y][n.x].isMine)
                        gameField[y][x].countMineNeighbors += 1;
                }
            }
        }
    }
    private List<GameObject> getNeighbors(GameObject gameObject) {
        List<GameObject> neighbors = new ArrayList<>();
        for (int y = gameObject.y - 1; y < gameObject.y + 2; y++) {
            for (int x = gameObject.x - 1; x < gameObject.x + 2; x++) {
                if (x == gameObject.x && y == gameObject.y)
                    continue;
                if (x >= 0 && y >= 0 && x < SIDE && y < SIDE)
                    neighbors.add(gameField[y][x]);
            }
        }
        return neighbors;
    }
    private void openTile(int x, int y) {
        GameObject gObj = gameField[y][x];
        if (isGameStopped || gObj.isOpen || gObj.isFlag)
            return;
        gObj.isOpen = true;
        if (gObj.isMine) {
            setCellValueEx(x, y, Color.RED, MINE);
            gameOver();
            return;
        }

        score += 5;
        setScore(score);
        setCellColor(x, y, Color.AQUAMARINE);

        countClosedTiles--;
        if (countClosedTiles == countMinesOnField) {
            win();
            return;
        }

        int countMineNeighbors = gObj.countMineNeighbors;
        if (countMineNeighbors != 0) {
            setCellNumber(x, y, countMineNeighbors);
            return;
        }
        setCellValue(x, y, "");
        List<GameObject> neighbors = getNeighbors(gObj);
        for (GameObject neighbor : neighbors)
            if (!neighbor.isOpen)
                openTile(neighbor.x, neighbor.y);
    }
    private void markTile(int x, int y) {
        if (isGameStopped)
            return;
        if (gameField[y][x].isOpen)
            return;
        if (countFlags == 0 && !gameField[y][x].isFlag)
            return;
        if (!gameField[y][x].isFlag) {
            gameField[y][x].isFlag = true;
            countFlags--;
            setCellValue(x, y, FLAG);
            setCellColor(x, y, Color.YELLOW);
        }
        else {
            gameField[y][x].isFlag = false;
            countFlags++;
            setCellValue(x, y, "");
            setCellColor(x, y, CELL_COLOR);
        }
    }
    private void gameOver() {
        isGameStopped = true;
        showMessageDialog(Color.WHITE, "GAME OVER", Color.BLACK, 36);
    }
    private void win() {
        isGameStopped = true;
        showMessageDialog(Color.WHITE, "YOU WIN", Color.BLACK, 36);
    }
    private void restart() {
        isGameStopped = false;
        countClosedTiles = SIDE * SIDE;
        countMinesOnField = 0;
        score = 0;
        setScore(score);
        createGame();
    }
    @Override
    public void onMouseLeftClick(int x, int y)
    {
        if (isGameStopped) {
            restart();
        } else {
            openTile(x, y);
        }
    }
    @Override
    public void onMouseRightClick(int x, int y) {
        markTile(x, y);
    }
}
