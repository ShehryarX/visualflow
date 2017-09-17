import com.google.gson.Gson;
import com.google.gson.GsonBuilder;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;
import java.util.HashMap;
import java.util.TreeMap;
import java.util.TreeSet;

public class HackTheNorth {

    static HashMap<Integer, Person> database;

    public static void main(String args[]) {
        database = new HashMap<>();

        BufferedReader reader = null;

        TreeSet<Person> cities = new TreeSet<>();
        TreeMap<String, Integer> start_date = new TreeMap<>();

        try {
            reader = new BufferedReader(new FileReader(new File("/home/shehryar/IdeaProjects/ICS4U/src/policy_info_json.txt")));
            Gson gson = new GsonBuilder().create();
            // Participant data
            /*reader = new BufferedReader(new FileReader(new File("/home/shehryar/IdeaProjects/ICS4U/src/data_participants_json.txt")));

            Person[] people = gson.fromJson(reader, Person[].class);

            for(int i = 0; i < people.length; i++) {
                database.put(people[i].id, people[i]);
                //cities.add(people[i]);
            }

            //int[] a = {1, 2, 3};

            //StringBuilder out = new StringBuilder("{");
            //for(Person d : cities) {
            //    out.append("new Vector2(" + d.latitude + ", " + d.longitude + "), ");
            //}

            // System.out.println(out.substring(0, out.length() - 2) + ("}"));
*/
            // Policy information
            Policy[] policies = gson.fromJson(reader, Policy[].class);

            for(int i = 0; i < policies.length; i++) {
                String curr = policies[i].policy_start_date.substring(0, 10);

                if(start_date.containsKey(curr)) {
                    start_date.put(curr, start_date.get(curr) + 1);
                } else {
                    start_date.put(curr, 1);
                }
            }

            String x = gson.toJson(start_date);

            System.out.println(x);
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
        Policy policy;

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
            this.policy = null;
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

    public class Policy {
        int participant_id;
        String insurance_product;
        String insurance_coverage;
        String insurance_premium;
        int id;
        String insurance_plan;
        String policy_start_date;
        String collection_id;
        String _version_;

        public Policy(int participant_id, String insurance_product, String insurance_coverage, String insurance_premium, int id, String insurance_plan, String policy_start_date, String collection_id, String _version_) {
            this.participant_id = participant_id;
            this.insurance_product = insurance_product;
            this.insurance_coverage = insurance_coverage;
            this.insurance_premium = insurance_premium;
            this.id = id;
            this.insurance_plan = insurance_plan;
            this.policy_start_date = policy_start_date;
            this.collection_id = collection_id;
            this._version_ = _version_;
        }
    }
}
