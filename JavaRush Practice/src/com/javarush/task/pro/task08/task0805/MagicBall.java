package com.javarush.task.pro.task08.task0805;

import java.util.Random;

public class MagicBall {
    private static final String CERTAIN = "Бесспорно";
    private static final String DEFINITELY = "Определённо да";
    private static final String MOST_LIKELY = "Вероятнее всего";
    private static final String OUTLOOK_GOOD = "Хорошие перспективы";
    private static final String ASK_AGAIN_LATER = "Спроси позже";
    private static final String TRY_AGAIN = "Попробуй снова";
    private static final String NO = "Мой ответ — нет";
    private static final String VERY_DOUBTFUL = "Весьма сомнительно";

    public static String getPrediction() {
        String[] text = {CERTAIN, DEFINITELY, MOST_LIKELY, OUTLOOK_GOOD,
                ASK_AGAIN_LATER, TRY_AGAIN, NO, VERY_DOUBTFUL};
        int p = (new Random().nextInt(8));
        if (p >= 0 && p < 8)
            return text[p];
        return null;
    }
}
