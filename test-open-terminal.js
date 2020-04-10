const sqlite3 = require('sqlite3').verbose();
let db = new sqlite3.Database('facturas.db');

let tableName = "Facturas"

let initializeDb = (cb) => {

    db.run(`CREATE TABLE if not EXISTS  "${tableName}" (
        "Id" INT PRIMARY KEY,
        "NumeroFactura"	TEXT,
        "Condiciones"	TEXT,
        "Cedula"	TEXT,
        "FechaFactura"	TEXT,
        "Monto"	TEXT,
        "Estado" TEXT)`, (res, err) => {
        console.log('Creada res: ', res)
        console.log('Creada err: ', err)
        // cb()
    });

}

// NumeroFactura, Condiciones, Cedula, FechaFactura, Monto, Estado

let select = (cedula) => {
    console.log('### NODE COMMAND LINE PARAMETER ###')
    console.log('La cedula a buscar es:', cedula)

    let sql =
        `select * from ${tableName} where Cedula='${cedula}'
    `
    db.all(sql, (err, row) => {
        if (err) console.log('Hubo un error: ', err)
        console.log(row)
    })

}
let cedula = process.argv[2]
select(cedula)
