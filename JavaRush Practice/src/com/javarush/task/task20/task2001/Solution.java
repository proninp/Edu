package com.javarush.task.task20.task2001;

import java.io.*;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

/* 
Читаем и пишем в файл: Human
*/

public class Solution {
    public static void main(String[] args) {
        //исправьте outputStream/inputStream в соответствии с путем к вашему реальному файлу
        try {
            File your_file_name = File.createTempFile("your_file_name", null);
            OutputStream outputStream = new FileOutputStream(your_file_name);
            InputStream inputStream = new FileInputStream(your_file_name);

            Human ivanov = new Human("Ivanov", new Asset("home", 999_999.99), new Asset("car", 2999.99));
            ivanov.save(outputStream);
            outputStream.flush();

            Human somePerson = new Human();
            somePerson.load(inputStream);
            inputStream.close();

            System.out.println(ivanov.equals(somePerson));

        } catch (IOException e) {
            //e.printStackTrace();
            System.out.println("Oops, something wrong with my file");
        } catch (Exception e) {
            //e.printStackTrace();
            System.out.println("Oops, something wrong with save/load method");
        }
    }

    public static class Human {
        public String name;
        public List<Asset> assets = new ArrayList<>();

        public Human() {
        }

        public Human(String name, Asset... assets) {
            this.name = name;
            if (assets != null) {
                this.assets.addAll(Arrays.asList(assets));
            }
        }

        @Override
        public boolean equals(Object o) {
            if (this == o) return true;
            if (o == null || getClass() != o.getClass()) return false;

            Human human = (Human) o;

            if (name != null ? !name.equals(human.name) : human.name != null) return false;
            return assets != null ? assets.equals(human.assets) : human.assets == null;
        }

        @Override
        public int hashCode() {
            int result = name != null ? name.hashCode() : 0;
            result = 31 * result + (assets != null ? assets.hashCode() : 0);
            return result;
        }

        public void save(OutputStream outputStream) throws Exception {
            if (this.name != null) {
                outputStream.write("name\n".getBytes());
                outputStream.write((this.name + "\n").getBytes());
            }
            if (this.assets != null && this.assets.size() > 0) {
                outputStream.write("assets\n".getBytes());
                for (Asset a: assets) {
                    outputStream.write("asset\n".getBytes());
                    if (a.getName() != null) {
                        outputStream.write("aname\n".getBytes());
                        outputStream.write((a.getName() + "\n").getBytes());
                    }
                    outputStream.write("aprice\n".getBytes());
                    outputStream.write((a.getPrice() + "\n").getBytes());
                }
            }
        }

        public void load(InputStream inputStream) throws Exception {
            BufferedReader bf = new BufferedReader(new InputStreamReader(inputStream));
            while (bf.ready()) {
                String line = bf.readLine();
                if ("name".equals(line)) {
                    this.name = bf.readLine();
                } else if ("assets".equals(line)) {
                    this.assets = new ArrayList<>();
                } else if("asset".equals(line)) {
                    String assetName = null;
                    double assetPrice = 0;
                    String assetLine = bf.readLine();
                    if ("aname".equals(assetLine)) {
                        assetName = bf.readLine();
                        assetLine = bf.readLine();
                    }
                    if ("aprice".equals(assetLine)) {
                        assetPrice = Double.parseDouble(bf.readLine());
                    }
                    this.assets.add(new Asset(assetName, assetPrice));
                }
            }
            bf.close();
        }
    }
}
