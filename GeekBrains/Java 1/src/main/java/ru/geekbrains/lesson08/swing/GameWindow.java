package ru.geekbrains.lesson08.swing;

import javax.swing.*;
import javax.swing.text.SimpleAttributeSet;
import javax.swing.text.StyleConstants;
import javax.swing.text.StyledDocument;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

public class GameWindow extends JFrame {
    private JTextPane textPane;
    private int randomNumber;
    private int attemptsCount;

    public GameWindow() {
        setTitle("Game: Guess number");
        setBounds(600, 300, 800, 160);
        setDefaultCloseOperation(EXIT_ON_CLOSE);
        // setLayout(new BorderLayout());
        setResizable(false);

        textPane = new JTextPane();
        add(textPane, BorderLayout.NORTH);

        StyledDocument style = textPane.getStyledDocument();
        SimpleAttributeSet align = new SimpleAttributeSet();
        StyleConstants.setAlignment(align, StyleConstants.ALIGN_CENTER);
        style.setParagraphAttributes(0, style.getLength(), align, false);

        textPane.setEditable(false);
        textPane.setAlignmentX(SwingConstants.CENTER);
        textPane.setAlignmentY(SwingConstants.CENTER);
        Font font = new Font("Arial", Font.PLAIN, 18);
        textPane.setFont(font);

        JMenuBar menuBar = new JMenuBar();
        setMenuBar(menuBar);
        setJMenuBar(menuBar);

        JPanel buttonsPanel = new JPanel(new GridLayout(1, 10));
        add(buttonsPanel, BorderLayout.CENTER);

        for (int i = 1; i <= 10; i++) {
            JButton button = new JButton(String.valueOf(i));
            button.setFont(font);
            buttonsPanel.add(button);

            int buttonIndex = i;
            button.addActionListener(new ActionListener() {
                @Override
                public void actionPerformed(ActionEvent e) {
                    tryToAnswer(buttonIndex);
                }
            });
        }

        newGame();
        setVisible(true);
    }

    private void tryToAnswer(int answer) {
        if (attemptsCount == 0) {
            textPane.setText("You've run out of attempts. Start a new game.\n");
            return;
        }
        if (answer == randomNumber) {
            textPane.setText("You guessed it! Answer: " + randomNumber + "\n");
        } else {
            if (--attemptsCount == 0) {
                textPane.setText("You've run out of attempts. Start a new game.\n");
                return;
            }
            if (answer > randomNumber) {
                textPane.setText("You didn't guess! The hidden number is less than " + answer + ".\n" + attemptsCount + " attempts left.");
            } else {
                textPane.setText("You didn't guess! The hidden number is greater than " + answer + ".\n" + attemptsCount + " attempts left.");
            }
        }
    }

    private void newGame() {
        this.randomNumber = (int) (Math.random() * 10) + 1; // [1, 10]
        attemptsCount = 3;
        if (textPane != null) {
            textPane.setText("The program made a number from 1 to 10\n");
        }
    }

    private void setMenuBar(JMenuBar menuBar) {
        Font font = new Font("Arial", Font.PLAIN, 12);

        JMenu gameMenu = new JMenu("Menu");
        gameMenu.setFont(font);

        JMenuItem restartMenuItem = new JMenuItem("Restart game");
        restartMenuItem.setFont(font);
        restartMenuItem.setAccelerator(KeyStroke.getKeyStroke('N', Toolkit.getDefaultToolkit().getMenuShortcutKeyMaskEx()));
        gameMenu.add(restartMenuItem);

        restartMenuItem.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                newGame();
            }
        });

        gameMenu.addSeparator();

        JMenuItem exitMenuItem = new JMenuItem("Exit");
        exitMenuItem.setFont(font);
        exitMenuItem.setAccelerator(KeyStroke.getKeyStroke('Q', Toolkit.getDefaultToolkit().getMenuShortcutKeyMaskEx()));
        gameMenu.add(exitMenuItem);

        exitMenuItem.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                System.exit(0);
            }
        });
        menuBar.add(gameMenu);
    }
}
