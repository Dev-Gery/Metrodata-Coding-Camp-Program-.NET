$.ajax({
    url: "https://pokeapi.co/api/v2/pokemon?limit=1400&offset=0",
    success: function (result) {
        console.log(result.results);
        var text = "";
        $.each(result.results, function (key, val){
            text += `<tr>
                        <td>${key+1}</td>
                        <td>${val.name}</td>
                        <td><button class="btn btn-primary" data-toggle="modal" data-target="#detailModal"
                            onclick="popup('${val.url}')">
                            Detail
                            </button></td>
                    </tr>`;
        });
        console.log(text);
        $("#tablePokemon").html(text);
    }
})

function popup(url) {
    $.ajax({
        url: url,
        success: function (result) {
            $('.picture').attr('src', `${result.sprites.other['official-artwork'].front_default}`);
            $('.name').html(result.name);
            var text = "";
            var typeColor = "";
            $.each(result.types, function (key, val) {
                switch (val.type.name) {
                    case "normal":
                        typeColor = "#A8A77A";
                        break;
                    case "fire":
                        typeColor = "#EE8130";
                        break;
                    case "water":
                        typeColor = "#6390F0";
                        break;
                    case "grass":
                        typeColor = "#7AC74C";
                        break;
                    case "electric":
                        typeColor = "#F7D02C";
                        break;
                    case "ice":
                        typeColor = "#96D9D6";
                        break;
                    case "fighting":
                        typeColor = "#C22E28";
                        break;
                    case "poison":
                        typeColor = "#A33EA1";
                        break;
                    case "ground":
                        typeColor = "#E2BF65";
                        break;
                    case "flying":
                        typeColor = "#A98FF3";
                        break;
                    case "psychic":
                        typeColor = "#F95587";
                        break;
                    case "bug":
                        typeColor = "#A6B91A";
                        break;
                    case "ghost":
                        typeColor = "#735797";
                        break;
                    case "dragon":
                        typeColor = "#6F35FC";
                        break;
                    case "dark":
                        typeColor = "#705746";
                        break;
                    case "steel":
                        typeColor = "#B7B7CE";
                        break;
                    case "fairy":
                        typeColor = "#D685AD";
                        break;
                    default:
                        typeColor = "white";
                }
                text += `<span 
                            class="badge badge-pill" style="background-color: ${typeColor}">${val.type.name}
                        </span>`;
            });
            $("#types").html(text);
            text = "";
            $.each(result.abilities, function (key, val) {
                text += `<tr>
                        <td>${val.ability.name}</td>
                        </tr>`;
            });
            console.log('abilities', text);
            $("#tableAbilities").html(text);
            text = "";
            $.each(result.moves, function (key, val) {
                text += `<tr>
                        <td>${val.move.name}</td>
                        </tr>`;
            });
            $("#tableMoves").html(text);
            $('.vty').css({ "width": `${result.stats[0].base_stat}%` })
            $('.atk').css({ "width": `${result.stats[1].base_stat}%` })
            $('.dse').css({ "width": `${result.stats[2].base_stat}%` })
            $('.sclatk').css({ "width": `${result.stats[3].base_stat}%` })
            $('.scldse').css({ "width": `${result.stats[4].base_stat}%` })
            $('.spd').css({ "width": `${result.stats[5].base_stat}%` })
        }
    })
}

$(document).ready(function () {
    $('.tablePokemon').DataTable();
});