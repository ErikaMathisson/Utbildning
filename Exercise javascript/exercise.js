/*
* Function for determine if input year is a leap year and print the result to the user.
*/
function leapYear()
{
	var text;
	var input;
	
	input = document.getElementById("inputYear").value;
	//validate if the input is a numer
	if(isNaN(input))
	{	
		text ="Not a valid input...";	
	}
	else
	{
		if(input % 4 == 0)
		{
			text ="Input year is a leap year!";		
		}
		else
		{
			text = "Not a leap year... ";			
		}	
	}
	document.getElementById("outputYear").innerHTML = text;	
};
/*
* Function for taking an input and compare to a random number generated.
*/
function digitRandom()
{
	var text;
	var input = document.getElementById("digit").value;
	var rand = Math.ceil(Math.random() * 10);
	
	if(isNaN(input) || input < 1 || input > 10)
	{
		text = "Not a valid input...";		
	}
	else
	{
		if(input == rand)
		{
			text = "Your input: " + input + " is the same as the random number " + rand + " congratulations! ";			
		}
		else
		{
			text = "Your input: " + input + " is NOT the same as the random number " + rand + " sorry... ";			
		}	
		
	}
	
	document.getElementById("outputRandom").innerHTML = text;
	
};