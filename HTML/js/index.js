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
            menu.className = "menuOn";    
        else    
            menu.className = "menuOff";    
           
}
function loadDoom(){
    /*All credit to js-dos.com and @evilution as well as id-software*/
    /*Doom source code is available at: https://github.com/id-Software/DOOM*/
    document.write("\<!doctype html\>" +
     "<html lang=\"en-us\">"+
       "<head>" +
        "<meta charset=\"utf-8\">" +
        "<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\">" +
        "<title>DOOM</title>" +
        "<style type=\"text/css\">" +
           ".dosbox-container { width: 320px; height: 200px;}" +
           ".dosbox-container > .dosbox-overlay { background: url(https://js-dos.com/cdn/DOOM.png); }" +
        "</style>" +
      "</head>" +
      "<body>" +
        "<div id=\"dosbox\"></div>" +
        "<br/>" +
        "<button onclick=\"dosbox.requestFullScreen();\">Make fullscreen</button>" +
        "<script type=\"text/javascript\" src=\"https://js-dos.com/cdn/js-dos-api.js\"></script>" +
        "<script type=\"text/javascript\">" +
          "var dosbox = new Dosbox({" +
            "id: \"dosbox\"," +
            "onload: function (dosbox) {" +
              "dosbox.run(\"upload/DOOM-@evilution.zip\", \"./doom\");" +
            "}," +
            "onrun: function (dosbox, app) {" +
              "console.log(\"App '\" + app + \"' is runned\");" +
            "}" +
          "});" +
        "</script>" +
      "</body>" +
    "</html>");
}