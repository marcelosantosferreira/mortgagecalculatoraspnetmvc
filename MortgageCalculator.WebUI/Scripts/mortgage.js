/*
* Returns the Monthly Payment
*/

function getMonthlyPayment(amount, interest, period)
{
    amount = parseFloat(amount);
    interest = parseFloat(interest);
    period = parseFloat(period);
    
    var _return = ((amount * Math.pow(1 + interest, period)) / ((Math.pow((1 + interest), period) - 1) / ((1 + interest) - 1)));
    _return = _return.toFixed(2);
    return _return;
}