using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace Store.API.Model
{
    public interface ICountryValues
    {
        string[] Values { get; }

        bool IsValid(string value);
    }

    public class CountryValues : ICountryValues
    {
        public string[] Values
        {
            get { return new string[] { "in", "fr", "au" }; }
        }


        public bool IsValid(string value)
        {
            return Values.Contains(value, StringComparer.CurrentCultureIgnoreCase);
        }
    }


    #region Custom Routing Constraint Implementation

    public class CountryValuesListConstraint : System.Web.Routing.IRouteConstraint
    {
        private readonly string[] _values;


        public CountryValuesListConstraint(params string[] values)
        {
            this._values = values;
        }

        public bool Match(HttpContextBase httpContext, Route route, string parameterName,
            RouteValueDictionary values,
            RouteDirection routeDirection)
        {
            // Get the value called "parameterName" from the
            // RouteValueDictionary called "value"
            string value = values[parameterName].ToString();
            // Return true is the list of allowed values contains
            // this value.
            return _values.Contains(value, StringComparer.CurrentCultureIgnoreCase);
        }
    }

    public class CountryValuesListConstraintDI : System.Web.Routing.IRouteConstraint
    {
        private ICountryValues _values;

        public CountryValuesListConstraintDI(ICountryValues values)
        {
            this._values = values;
        }

        public bool Match(HttpContextBase httpContext, Route route, string parameterName,
            RouteValueDictionary values,
            RouteDirection routeDirection)
        {
            // Get the value called "parameterName" from the
            // RouteValueDictionary called "value"
            string value = values[parameterName].ToString();
            // Return true is the list of allowed values contains
            // this value.
            return _values.IsValid(value);
        }
    }

    #endregion
}