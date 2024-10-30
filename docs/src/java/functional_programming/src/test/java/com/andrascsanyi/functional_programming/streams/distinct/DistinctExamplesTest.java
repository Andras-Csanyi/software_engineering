package com.andrascsanyi.functional_programming.streams.distinct;

import com.andrascsanyi.functional_programming.streams.Person;
import java.util.Arrays;
import java.util.List;
import org.junit.jupiter.api.Test;

import static org.assertj.core.api.Assertions.assertThat;

public class DistinctExamplesTest {

    @Test
    public void distinctNumbers(){

        List<Integer> numbers = Arrays.asList(1,1,2,2,3,3,4,4,5,5);
        List<Integer> distinctedList = numbers.stream()
            .distinct()
            .toList();

        assertThat(distinctedList.stream().filter(f -> f == 1).toList().size()).isEqualTo(1);
        assertThat(distinctedList.stream().filter(f -> f == 2).toList().size()).isEqualTo(1);
    }

    @Test
    public void distinctObjects(){
        List<Person> people = Arrays.asList(
            new Person(1L, "Albert"),
            new Person(1L, "Albert"),
            new Person(2L, "Alfa"),
            new Person(2L, "Alfa")
        );

        List<Person> distinctList = people.stream()
            .distinct()
            .toList();

        assertThat(distinctList.size()).isEqualTo(2);
    }

}