package com.andrascsanyi.functional_programming.streams.filter;

import com.andrascsanyi.functional_programming.streams.Person;
import java.util.Arrays;
import java.util.List;
import org.junit.jupiter.api.Test;

import static org.assertj.core.api.Assertions.assertThat;

public class FilterExamplesTest {

    @Test
    public void filterSimpleValues() {
        List<Integer> integers = Arrays.asList(1, 2, 3, 4, 5, 6, 8, 9, 10);
        List<Integer> evenNumbers = integers.stream()
            .filter(number -> number % 2 == 0)
            .toList();

        assertThat(evenNumbers).contains(2, 4, 6, 8, 10);
        assertThat(evenNumbers).doesNotContain(1, 3, 5, 7, 9);
    }

    @Test
    public void chainingFiltersWithSimpleValues(){
        List<Integer> integers = Arrays.asList(1, 2, 3, 4, 5, 6, 8, 9, 10);
        List<Integer> evenNumbers = integers.stream()
            .filter(number -> number % 2 == 0)
            .filter(number -> number > 4)
            .toList();

        assertThat(evenNumbers).contains(6, 8, 10);
        assertThat(evenNumbers).doesNotContain(1, 2, 3, 4, 5, 7, 9);
    }

    @Test
    public void filterObjects(){
        List<Person> people = Arrays.asList(
            new Person(1L, "Andrea"),
            new Person(2L, "Bela"),
            new Person(3L, "Cecil"),
            new Person(4L, "David")
        );

        List<Person> filteredPeople = people.stream()
            .filter(p -> p.id() < 3)
            .toList();

        assertThat(filteredPeople).contains(
            new Person(1L, "Andrea"),
            new Person(2L, "Bela")
        );
        assertThat(filteredPeople).doesNotContain(
            new Person(3L, "Cecil"),
            new Person(4L, "David")
        );
    }

}