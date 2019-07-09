var fPeriod = document.getElementById("Period");


function CheckSubscript() {
    var fsubScriptTest = document.getElementById("IsSubscriptionCheck");        
    if (fsubScriptTest.checked == true)
    {
        document.getElementById("Period").style.display = "inline";
        document.getElementById("FinDateLab").style.display = "inline";
        document.getElementById("FinDateInp").style.display = "inline";
        document.getElementById("RateLab").style.display = "inline";
        document.getElementById("RateInp").style.display = "inline";
    } else
    {
        document.getElementById("Period").style.display = "none";
        document.getElementById("FinDateLab").style.display = "none";
        document.getElementById("FinDateInp").style.display = "none";
        document.getElementById("RateLab").style.display = "none";
        document.getElementById("RateInp").style.display = "none";
    }
}


function createEventListeners() {
    CheckSubscript();
    var fsubScript = document.getElementById("IsSubscriptionCheck");
    if (fsubScript.addEventListener) {
        fsubScript.addEventListener("click", CheckSubscript, false);
    } else if (fsubScript.attachEvent) {
        fsubScript.attachEvent("click", CheckSubscript);
    }
}

if (window.addEventListener) {
    window.addEventListener("load", createEventListeners, false);
} else if (window.attachEvent) {
    window.attachEvent("onload", createEventListeners);
}
