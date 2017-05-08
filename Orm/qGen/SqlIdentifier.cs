using Lazaro.Orm.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace qGen
{
        /// <summary>
        /// Represents an SQL identifier like a table name, column name, index name, etc.
        /// 
        /// An SQL identifier can have up to three parts, an optional prefix, the identifier name and
        /// an optional alias, in the form "prefix.name AS alias".
        /// </summary>
        public class SqlIdentifier
        {
                // Any of these characters indicate it's not a real identifier by probably an expression
                public static readonly char[] InvalidIdentifierChars = new char[] { '(', '-', '/', '+', '*' };

                // Characters to remove when removing quoting
                protected static readonly char[] IdentifierQuoteChars = new char[] { '`', '"', '[', ']', ' ' };

                public string Prefix { get; set; }
                public string Name { get; set; }
                public string Alias { get; set; }

                public SqlIdentifier(string prefix, string name, string alias)
                {
                        this.FromString(prefix, name, alias);
                }

                public SqlIdentifier(string name, string alias)
                {
                        this.FromString(name, alias);
                }

                public SqlIdentifier(string definition)
                {
                        this.FromString(definition);
                }

                public void FromString(string prefix, string name, string alias)
                {
                        if (string.IsNullOrEmpty(prefix) == false) {
                                this.Prefix = prefix.Trim(IdentifierQuoteChars);
                        }

                        this.Name = name.Trim(IdentifierQuoteChars);

                        if (string.IsNullOrEmpty(alias) == false) {
                                this.Alias = alias.Trim(IdentifierQuoteChars);
                        }
                }

                public void FromString(string name, string alias)
                {
                        if(name.IndexOf(".") >= 0 && IsValidIdentifierName(name)) {
                                // If there's a dot we split prefix and name, unless there's an expression, which we will not evaluate
                                var NameParts = name.Split(new char[] { '.' }, 2);
                                this.FromString(NameParts[0], NameParts[1], alias);
                        } else {
                                this.FromString(null, name, alias);
                        }
                }

                public void FromString(string definition)
                {
                        if (definition.IndexOf(" AS ", StringComparison.InvariantCultureIgnoreCase) >= 0) {
                                var IndexOfAs = definition.ToUpperInvariant().IndexOf(" AS ");
                                var DefParts = new string[] { definition.Substring(0, IndexOfAs), definition.Substring(IndexOfAs + 4) }; 
                                this.FromString(DefParts[0], DefParts[1]);
                        } else {
                                if (definition.IndexOf(".") >= 0 && IsValidIdentifierName(definition)) {
                                        var NameParts = definition.Split(new char[] { '.' }, 2);
                                        this.FromString(NameParts[0], NameParts[1], null);
                                } else {
                                        this.FromString(null, definition, null);
                                }
                        }
                }

                /// <summary>
                /// Gets prefix.name (unquoted).
                /// </summary>
                public string PrefixAndName
                {
                        get
                        {
                                return string.IsNullOrEmpty(this.Prefix)
                                        ? this.Name
                                        : this.Prefix + "." + this.Name;
                        }
                }

                /// <summary>
                /// Gets the identifier complete definition, like "prefix.name AS alias" (unquoted).
                /// </summary>
                public string Definition
                {
                        get
                        {
                                return string.IsNullOrEmpty(this.Alias)
                                        ? this.PrefixAndName
                                        : this.PrefixAndName + " AS " + this.Alias;
                        }
                }

                public bool IsRealIdentifier
                {
                        get
                        {
                                return IsValidIdentifierName(this.PrefixAndName);
                        }
                }

                public static bool IsValidIdentifierName(string identifier)
                {
                        return identifier.IndexOfAny(InvalidIdentifierChars) < 0 && identifier.All(Char.IsDigit) == false;
                }

                /// <summary>
                /// Returns true if the given (possibly incomplete) identifier definition equals this.
                /// 
                /// For example, "table.column".EqualsByName("column") is true.
                /// </summary>
                /// <param name="identifierDefinition"></param>
                /// <returns></returns>
                public bool EqualsByName(string identifierDefinition)
                {
                        var IsEqual = string.Compare(identifierDefinition, this.Name, StringComparison.InvariantCultureIgnoreCase) == 0
                                || string.Compare(identifierDefinition, this.PrefixAndName, StringComparison.InvariantCultureIgnoreCase) == 0
                                || string.Compare(identifierDefinition, this.Definition, StringComparison.InvariantCultureIgnoreCase) == 0
                                || string.Compare(identifierDefinition, this.ToString(), StringComparison.InvariantCultureIgnoreCase) == 0;
                        if (IsEqual == false) {
                                // Try again, using identifier name only... no prefix or alias.
                                var identifierNameOnly = ColumnValue.GetNameOnly(identifierDefinition);
                                IsEqual = string.Compare(identifierNameOnly, this.Name, StringComparison.InvariantCultureIgnoreCase) == 0
                                || string.Compare(identifierNameOnly, this.PrefixAndName, StringComparison.InvariantCultureIgnoreCase) == 0
                                || string.Compare(identifierNameOnly, this.Definition, StringComparison.InvariantCultureIgnoreCase) == 0
                                || string.Compare(identifierNameOnly, this.ToString(), StringComparison.InvariantCultureIgnoreCase) == 0;
                        }

                        return IsEqual;
                }


                internal bool EqualsByName(SqlIdentifier identifier)
                {
                        return string.Compare(identifier.Name, this.Name, StringComparison.InvariantCultureIgnoreCase) == 0
                                || string.Compare(identifier.Prefix, this.PrefixAndName, StringComparison.InvariantCultureIgnoreCase) == 0
                                || string.Compare(identifier.Definition, this.Definition, StringComparison.InvariantCultureIgnoreCase) == 0
                                || string.Compare(identifier.ToString(), this.ToString(), StringComparison.InvariantCultureIgnoreCase) == 0;
                }

                public override string ToString()
                {
                        return SqlFormatter.DefaultFormatter.SqlText(this);
                }
        }
}
