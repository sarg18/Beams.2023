namespace Beams.logic
{
    public class MyBeams
    {
        private readonly string _text;


        public MyBeams(string text)
        {
            _text = text;
        }
        public string IsValid()
        {
            char n = _text[0];
            if (n != '#' && n != '%' && n != '&')
            {
                return "la base no es valida";
            }

            int conConec = 0;
            for (int i = 1; i < _text.Length; i++)
                if (!(_text[i].Equals('=') || _text[i].Equals('*')))
                {
                    return "la viga esta mal construida ";
                }
            for (int i = 1; i < _text.Length; i++)
                if (_text[i].Equals('*'))
                {
                    conConec++;

                    if (conConec == 2)
                    {
                        return "la viga esta mal construida";
                    }
                }
                else
                {
                    conConec = 0;
                }


            return "la viga es valida";

        }


        public int IsWeigth()
        {
            int suport = 0;
            int BaseWeigth = 0;
            int cont1 = 0;
            int contotal = 0;
            int contbeam = 0;
            if (_text[0] == '%')
            {
                BaseWeigth = 10;
            }
            if (_text[0] == '&')
            {
                BaseWeigth = 30;
            }
            if (_text[0] == '#')
            {
                BaseWeigth = 90;
            }


            for (int i = 1; i < _text.Length; i++)
            {
                if (_text[i].Equals('='))
                {
                    cont1++;
                    contbeam += cont1;
                }
                else
                {
                    contotal += contbeam;
                    contotal += contbeam * 2;
                    cont1 = 0;
                    contbeam = 0;
                }

            }
            suport = BaseWeigth - contotal;

            return suport;
        }

        public string ValidateWeigth()
        {
            if (IsValid() == "la viga es valida")
            {
                if (IsWeigth() < 0)
                {
                    return "la viga no resiste el peso";
                }
                else
                {
                    return "la viga resiste el peso";
                }
            }
            return string.Empty;
        }
    }

}