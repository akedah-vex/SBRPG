using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ServerRegions
{
    static (string code, string name) ASIA = (
        code: "asia", 
        name: "Asia, Singapore"
    );

    static (string code, string name) AUSTRALIA = (
        code: "au",
        name: "Australia, Melbourne"
    );

    static (string code, string name) CANADA_EAST = (
        code: "cae",
        name: "Canada, East"
    );

    static (string code, string name) EUROPE = (
        code: "eu",
        name: "Europe, Amsterdam"
    );

    static (string code, string name) INDIA = (
        code: "in",
        name: "India, Chennai"
    );

    static (string code, string name) JAPAN = (
        code: "jp",
        name: "Japan, Tokyo"
    );

    static (string code, string name) SOUTH_AFRICA = (
        code: "za",
        name: "South Africa, Johannesburg"
    );

    static (string code, string name) SOUTH_AMERICA = (
        code: "sa",
        name: "South America, Sao Paulo"
    );

    static (string code, string name) SOUTH_KOREA = (
        code: "kr",
        name: "South Korea, Seoul"
    );

    static (string code, string name) TURKEY = (
        code: "tr",
        name: "Turkey, Instanbul"
    );

    static (string code, string name) USA_EAST = (
        code: "us",
        name: "USA, East"
    );

    static (string code, string name) USA_WEST = (
        code: "usw",
        name: "USA, West"
    );

    public static List<(string, string)> list = new List<(string, string)>()
    {
        ASIA,
        AUSTRALIA,
        CANADA_EAST,
        EUROPE,
        INDIA,
        JAPAN,
        SOUTH_AFRICA,
        SOUTH_AMERICA,
        SOUTH_KOREA,
        TURKEY,
        USA_EAST,
        USA_WEST
    };
}
