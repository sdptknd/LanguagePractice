package com.sid.myapp.utils;

import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.*;

class StringMagicTest {

    @Test
    void shouldReserveGivenString() {
        assertEquals("cba", new StringMagic().reverse("abc"), "Reverse is not working");
    }
}