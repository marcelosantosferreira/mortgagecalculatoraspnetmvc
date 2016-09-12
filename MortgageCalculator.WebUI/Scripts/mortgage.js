/*
p - mortgage amount
r - rate-> interests
y - years
*/

function mortgagePayment(p,r,y)
{
    console.log("p: " + p);
    console.log("r: " + r);
    console.log("y: " + y);
	return futureValue(p,r,y)/geomSeries(1+r,0,y-1);
}

function futureValue(p,r,y)
{
	return p*Math.pow(1+r,y);
}

function geomSeries(z,m,n)
{
	var amt;
	if (z == 1.0) amt = n + 1;
	else amt = (Math.pow(z,n + 1) - 1)/(z - 1);
	if (m >= 1) amt -= geomSeries(z,0,m-1);
	return amt;
}

function zeroBlanks(formname)
{
	var i, ctrl;
	for (i = 0; i < formname.elements.length; i++)
	{
		ctrl = formname.elements[i];
		if (ctrl.type == "text")
		{
			if (makeNumeric(ctrl.value) == "")
				ctrl.value = "0";
		}
	}
}

function makeNumeric(s)
{
	return filterChars(s, "1234567890.-");
}

function filterChars(s, charList)
{
	var s1 = "" + s; // force s1 to be a string data type
	var i;
	for (i = 0; i < s1.length; )
	{
		if (charList.indexOf(s1.charAt(i)) < 0)
			s1 = s1.substring(0,i) + s1.substring(i+1, s1.length);
		else
			i++;
	}
	return s1;
}

function numval(val,digits,minval,maxval)
{
    console.info(val);
    val = makeNumeric(val);
	if (val == "" || isNaN(val)) val = 0;
	val = parseFloat(val);
	if (digits != null)
	{
		var dec = Math.pow(10,digits);
		val = (Math.round(val * dec))/dec;
	}
	if (minval != null && val < minval) val = minval;
	if (maxval != null && val > maxval) val = maxval;
	console.warn(val);
	return parseFloat(val);
}

function formatNumber(val,digits,minval,maxval)
{
	var sval = "" + numval(val,digits,minval,maxval);
	var i;
	var iDecpt = sval.indexOf(".");
	if (iDecpt < 0) iDecpt = sval.length;
	if (digits != null && digits > 0)
	{
		if (iDecpt == sval.length)
			sval = sval + ".";
		var places = sval.length - sval.indexOf(".") - 1;
		for (i = 0; i < digits - places; i++)
			sval = sval + "0";
	}
	var firstNumchar = 0;
	if (sval.charAt(0) == "-") firstNumchar = 1;
	for (i = iDecpt - 3; i > firstNumchar; i-= 3)
		sval = sval.substring(0, i) + "," + sval.substring(i);

	return sval;
}