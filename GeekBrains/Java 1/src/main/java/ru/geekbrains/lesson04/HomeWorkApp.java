package ru.geekbrains.lesson04;

import java.util.Random;
import java.util.Scanner;

public class HomeWorkApp {
    private static final int SIZE = 3;
    private static final char EMPTY_DOT = '*';
    private static final char X_DOT = 'X';
    private static final char O_DOT = 'O';
    private static char[][] map;
    private static Scanner scanner;
    private static Random random;

    public static void main(String[] args) {
        play();
    }

    /**
     * New game function
     */
    public static void play() {
        scanner = new Scanner(System.in);
        random = new Random();
        initMap();
        while (true) {
            if (playerMove()) break;
            if (pcMove()) break;
        }
    }

    /**
     * Initialize battle map
     */
    private static void initMap() {
        map = new char[SIZE][SIZE];
        for (int i = 0; i < SIZE; i++) {
            for (int j = 0; j < SIZE; j++) {
                map[i][j] = EMPTY_DOT;
            }
        }
        printMap();
    }

    /**
     * Function allows player to make a move
     */
    private static boolean playerMove() {
        int x, y;
        do {
            System.out.println("Enter coordinates in X Y format:");
            x = scanner.nextInt() - 1;
            y = scanner.nextInt() - 1;
        } while (!isValidMove(x, y));
        map[y][x] = X_DOT;
        printMap();
        return (checkGameOver(X_DOT, "You win!"));
    }

    /**
     * Function allows AI to make a move
     */
    private static boolean pcMove() {
        int x, y;
        do {
            x = random.nextInt(SIZE);
            y = random.nextInt(SIZE);
        } while (!isValidMove(x, y));
        map[y][x] = O_DOT;
        System.out.println("PC make a move: [ " + (x + 1) + "; " + (y + 1) + " ]");
        printMap();
        return (checkGameOver(O_DOT, "PC wins!"));
    }

    /**
     * Check ability to set a point in current point
     *
     * @param x - horizontal coordinate
     * @param y - vertical coordinate
     * @return - ability
     */
    private static boolean isValidMove(int x, int y) {
        return (x >= 0 && y >= 0) && (x < SIZE && y < SIZE) && map[y][x] == EMPTY_DOT;
    }

    /**
     * Check if User or PC win the game
     *
     * @param toCompare - Character that refers to User/PC
     * @param message   - The text of the message that will be shown in win case
     * @return - check result
     */
    private static boolean checkGameOver(char toCompare, String message) {
        int sumToCompare = ((int) toCompare) * SIZE; // sum of consecutive characters
        int topToBottomSum = 0; // first diagonal
        int bottomToTopSum = 0; // second diagonal
        boolean isNewMoveExists = false;
        for (int i = 0; i < map.length; i++) {
            int rowSum = 0;
            int columnSum = 0;
            for (int j = 0; j < SIZE; j++) {
                rowSum += map[i][j];
                columnSum += map[j][i]; // only if we have square battle map
                if (i == j) { // top to bottom diagonal
                    topToBottomSum += map[i][j];
                }
                if ((i + j) == (SIZE - 1)) { // bottom to top diagonal
                    bottomToTopSum += map[i][j];
                }
                if ((!isNewMoveExists) && (map[i][j] == EMPTY_DOT)) {
                    isNewMoveExists = true;
                }
            }
            if (rowSum == sumToCompare || columnSum == sumToCompare) {
                System.out.println(message);
                return true;
            }
        }
        if ((topToBottomSum == sumToCompare) || (bottomToTopSum == sumToCompare)) {
            System.out.println(message);
            return true;
        }
        if (!isNewMoveExists) { // the game will end if no empty spaces on the map
            System.out.println("There is no empty spaces for new move. Game over!");
            return true;
        }
        return false;
    }

    /**
     * Print battle map
     */
    private static void printMap() {
        System.out.print("\t");
        for (int i = 1; i <= SIZE; i++) {
            System.out.print(i + "\t");
        }
        System.out.println();
        for (int i = 0; i < SIZE; i++) {
            System.out.print(i + 1 + "\t");
            for (int j = 0; j < SIZE; j++) {
                System.out.print(map[i][j] + "\t");
            }
            System.out.println();
        }
    }
}
