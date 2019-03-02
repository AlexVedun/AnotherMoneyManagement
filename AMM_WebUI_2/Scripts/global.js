let isLogin = false;
let userLogin = "";
let isFamily = false;

const INCOME = 0;
const WASTE = 1;
const WALLET = 2;
const CARD = 3;

function GetSelectedItemId(_element) {
    let element = "#" + _element;
    return $(element + " option:selected").eq($(element).parent('li.selected').index()).val();
}