package com.sid.myapp;

import com.sid.myapp.utils.StringMagic;

public class Important {
    public static void main(String[] args) {
        String name = "John Doe";
        String reversedName = new StringMagic().reverse(name);
        System.out.println("Reversed name: " + reversedName);
    }
}