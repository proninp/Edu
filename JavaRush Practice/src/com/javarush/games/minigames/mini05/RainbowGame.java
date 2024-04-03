package com.javarush.games.minigames.mini05;

import com.javarush.engine.cell.Game;
import com.javarush.engine.cell.Color;

/* 
Цвета радуги
*/

public class RainbowGame extends Game {

    @Override
    public void initialize() {
        int w = 10, h = 7;
        setScreenSize(w, h);
        Color[] colors = {
                Color.RED,
                Color.ORANGE,
                Color.YELLOW,
                Color.GREEN,
                Color.BLUE,
                Color.INDIGO,
                Color.VIOLET
        };
        for (int i = 0; i < h; i++) {
            for (int j = 0; j < w; j++) {
                setCellColor(j, i, colors[i]);
            }
        }
    }
}
