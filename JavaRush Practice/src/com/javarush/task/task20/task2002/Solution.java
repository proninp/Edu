package com.javarush.task.task20.task2002;

import java.io.*;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

/* 
Читаем и пишем в файл: JavaRush
*/

public class Solution {
    public static void main(String[] args) {
        //you can find your_file_name.tmp in your TMP directory or adjust outputStream/inputStream according to your file's actual location
        //вы можете найти your_file_name.tmp в папке TMP или исправьте outputStream/inputStream в соответствии с путем к вашему реальному файлу
        try {
            File yourFile = File.createTempFile("your_file_name", null);
            OutputStream outputStream = new FileOutputStream(yourFile);
            InputStream inputStream = new FileInputStream(yourFile);

            JavaRush javaRush = new JavaRush();
            //initialize users field for the javaRush object here - инициализируйте поле users для объекта javaRush тут
            javaRush.save(outputStream);
            outputStream.flush();

            JavaRush loadedObject = new JavaRush();
            loadedObject.load(inputStream);
            //here check that the javaRush object is equal to the loadedObject object - проверьте тут, что javaRush и loadedObject равны

            outputStream.close();
            inputStream.close();

        } catch (IOException e) {
            //e.printStackTrace();
            System.out.println("Oops, something is wrong with my file");
        } catch (Exception e) {
            //e.printStackTrace();
            System.out.println("Oops, something is wrong with the save/load method");
        }
    }

    public static class JavaRush {
        public List<User> users = new ArrayList<>();

        public void save(OutputStream outputStream) throws Exception {
            if (this.users == null || this.users.size() == 0)
                return;
            outputStream.write("users\n".getBytes());
            for (User user: this.users) {
                outputStream.write("{\n".getBytes());
                if (user.getFirstName() != null) {
                    outputStream.write("firstName\n".getBytes());
                    outputStream.write((user.getFirstName() + "\n").getBytes());
                }
                if (user.getLastName() != null) {
                    outputStream.write("lastName\n".getBytes());
                    outputStream.write((user.getLastName() + "\n").getBytes());
                }
                if (user.getBirthDate() != null) {
                    outputStream.write("birthDate\n".getBytes());
                    outputStream.write((user.getBirthDate().getTime() + "\n").getBytes());
                }
                outputStream.write("isMale\n".getBytes());
                outputStream.write((user.isMale() + "\n").getBytes());
                if (user.getCountry() != null) {
                    outputStream.write("Country\n".getBytes());
                    outputStream.write((user.getCountry().getDisplayName() + "\n").getBytes());
                }
                outputStream.write("}\n".getBytes());
            }
        }

        public void load(InputStream inputStream) throws Exception {
            BufferedReader bf = new BufferedReader(new InputStreamReader(inputStream));
            if (bf.ready() && "users".equals(bf.readLine())) {
                this.users = new ArrayList<>();
                User user = null;
                while (bf.ready()) {
                    String property = bf.readLine();
                    if ("{".equals(property)) {
                        user = new User();
                    } else {
                        if (user == null) {
                            user = new User();
                        }
                        if ("firstName".equals(property)) {
                            user.setFirstName(bf.readLine());
                        } else if ("lastName".equals(property)) {
                            user.setLastName(bf.readLine());
                        } else if ("birthDate".equals(property)) {
                            user.setBirthDate(new Date(Long.parseLong(bf.readLine())));
                        } else if ("isMale".equals(property)) {
                            user.setMale(Boolean.parseBoolean(bf.readLine()));
                        } else if ("Country".equals(property)) {
                            String countryProperty = bf.readLine();
                            for(User.Country country: User.Country.values()) {
                                if (country.getDisplayName().equals(countryProperty)) {
                                    user.setCountry(country);
                                    break;
                                }
                            }
                        } else if (property.equals("}")) {
                            users.add(user);
                        }
                    }
                }
            }
            bf.close();
        }

        @Override
        public boolean equals(Object o) {
            if (this == o) return true;
            if (o == null || getClass() != o.getClass()) return false;

            JavaRush javaRush = (JavaRush) o;

            return users != null ? users.equals(javaRush.users) : javaRush.users == null;

        }

        @Override
        public int hashCode() {
            return users != null ? users.hashCode() : 0;
        }
    }
}
