getJoke();

function getJoke(){
    axios({
        method: 'get',
        url: 'https://v2.jokeapi.dev/joke/Programming'
    })
    .then(function(response){
        document.getElementById("punchline").innerText="";
        if(response.data.type=="twopart")
        {
        $joke = response.data.setup;
        $punchline = response.data.delivery;
        document.getElementById("joke").innerText=$joke;
        setTimeout(() => document.getElementById("punchline").innerText=$punchline, 4000);
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

function openMenu(){
        var menu = document.getElementById("dropDown");    
        if (menu.className == "menuOff")
        {
            menu.className = "menuOn";   
            setTimeout(() => menu.className = "menuOff", 10000);
        } 
        else    
            menu.className = "menuOff";    
           
}
