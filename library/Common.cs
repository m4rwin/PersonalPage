using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace martinhromek.library
{
  public static class Common
  {
    public enum BookGroup
    {
      Beletrie = 0,
      Naucne = 2,
      Serie = 3,
      Ostatni = 4,
      Chci = 5
    }

    public enum BookGenre
    {
      Scifi = 0,
      Fantasy = 1,
      Humor = 2,
      Krimi = 3,
      Horor = 4,
      Thriler = 5,
      Naucne = 6,
      IT = 7,
      Filozofie = 8,
      Historie = 9,
      Dobrodruzne = 10,
      Erotika = 11
     }

    public enum BookType
    {
      Nova = 0,
      Antikvariat = 1
    }
  }
}