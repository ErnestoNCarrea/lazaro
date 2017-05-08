using System;

namespace qGen
{
        public class FormatterParameters
        {
                public static FormatterParameters MySqlFormatterParameters = new FormatterParameters()
                {
                        IdentifierOpenQuote = "`",
                        IdentifierCloseQuote = "`",
                        StringOpenQuote = "'",
                        StringCloseQuote = "'",
                        DateTimeOpenQuote = "'",
                        DateTimeCloseQuote = "'"
                };

                public static FormatterParameters MySqlAnsiFormatterParameters = new FormatterParameters()
                {
                        IdentifierOpenQuote = "\"",
                        IdentifierCloseQuote = "\"",
                        StringOpenQuote = "'",
                        StringCloseQuote = "'",
                        DateTimeOpenQuote = "'",
                        DateTimeCloseQuote = "'"
                };

                public string IdentifierOpenQuote { get; set; }
                public string IdentifierCloseQuote { get; set; }
                public string StringOpenQuote { get; set; }
                public string StringCloseQuote { get; set; }
                public string DateTimeOpenQuote { get; set; }
                public string DateTimeCloseQuote { get; set; }
        }
}
