// Глобальные переменные
let isLogin = false;        // вошел ли пользователь в систему
let userLogin = "";         // логин пользователя
let isFamily = false;       // пока не используется

// Константы 
const INCOME = 0;           // поступление денег
const WASTE = 1;            // расход денег
const WALLET = 2;           // кошелек
const CARD = 3;             // карта

// Функция для получения выбранного элемента выпадающего списка
function GetSelectedItemId(_element) {
    let element = "#" + _element;
    return $(element + " option:selected").eq($(element).parent('li.selected').index()).val();
}