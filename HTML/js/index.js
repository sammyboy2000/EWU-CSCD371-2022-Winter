getJoke();

function getJoke(){
    axios({
        method: 'get',
        url: 'https://v2.jokeapi.dev/joke/Programming'
    })
    .then(function(response){
        clearPunchline();
        if(response.data.type=="twopart")
        {
        $joke = response.data.setup;
        $punchline = response.data.delivery;
        document.getElementById("joke").innerText=$joke;
        setTimeout(() => delayedPunchline($punchline), 4000);
        }
        else
        {
            document.getElementById("joke").innerText=response.data.joke;
        }
    })
    .catch(function  (error){
        document.getElementById("joke").innerText="Try again in a few seconds.";
    });
}

function delayedPunchline($punchline){
    clearPunchline();
    document.getElementById("punchline").innerText=$punchline;
}

function clearPunchline(){
    document.getElementById("punchline").innerText="";
}