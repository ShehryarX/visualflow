import com.google.gson.Gson;
import com.google.gson.GsonBuilder;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;

public class Parser {
    public static void main(String args[]) {
        BufferedReader reader = null;

        try {
            reader = new BufferedReader(new FileReader(new File("/home/shehryar/IdeaProjects/ICS4U/src/1.txt")));

            Gson gson = new GsonBuilder().create();
            Person[] person = gson.fromJson(reader, Person[].class);

            System.out.println("Object mode: " + person[0]);
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    static class Person {
        int id;
        String martial_status;
        String sex;
        double longitude;
        String state;
        String last_name;
        String date_added;
        String first_name;
        char dental_flag;
        String city;
        String postal_code;
        String birth_date;
        double latitude;
        String address_1;
        String collection_id;
        String _version_;

        public Person(int id, String martial_status, String sex, double longitude, String state, String last_name, String date_added, String first_name, char dental_flag, String city, String postal_code, String birth_date, double latitude, String address_1, String collection_id, String _version_) {
            this.id = id;
            this.martial_status = martial_status;
            this.sex = sex;
            this.longitude = longitude;
            this.state = state;
            this.last_name = last_name;
            this.date_added = date_added;
            this.first_name = first_name;
            this.dental_flag = dental_flag;
            this.city = city;
            this.postal_code = postal_code;
            this.birth_date = birth_date;
            this.latitude = latitude;
            this.address_1 = address_1;
            this.collection_id = collection_id;
            this._version_ = _version_;
        }

        @Override
        public String toString() {
            return "Person{" +
                    "id=" + id +
                    ", martialStatus=" + martial_status +
                    ", sex=" + sex +
                    ", longitude=" + longitude +
                    ", state='" + state + '\'' +
                    ", last_name='" + last_name + '\'' +
                    ", date_added='" + date_added + '\'' +
                    ", first_name='" + first_name + '\'' +
                    ", dental_flag=" + dental_flag +
                    ", city='" + city + '\'' +
                    ", postal_code='" + postal_code + '\'' +
                    ", birth_date='" + birth_date + '\'' +
                    ", latitude=" + latitude +
                    ", address_1='" + address_1 + '\'' +
                    ", collection_id='" + collection_id + '\'' +
                    ", version='" + _version_ + '\'' +
                    '}';
        }
    }
}
