var proto = window;
proto.templatesDir = '../components/';
proto.ComponentsPath = '../components/';
proto.webUrl = 'http://localhost:1704/';
//proto.webUrl = 'http://localhost:1561/';





proto.gproducts = {
    data: [{
        ID: 0, Name: 'User Inputs', object: null, ReturnedData: {}
    }]
}


String.prototype.ToMoney = function () {
    var str = this.valueOf();

    var results = parseFloat(String(str)).toFixed(2).replace(/./g, function (c, i, a) {
        return i && c !== "." && ((a.length - i) % 3 === 0) ? ',' + c : c;
    });


    return results;
};