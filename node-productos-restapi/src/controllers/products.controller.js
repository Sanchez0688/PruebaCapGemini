import { getConnection, sql } from "../database/connection.js";

export const getProducts = async (req, res) => {
  try {
    const pool = await getConnection();
    const result = await pool.request().query("SELECT * FROM product");
     
    return res.json(result.recordset);

  } catch (error) {
    res.status(500);
    res.send(error.message);
  }
};

export const createNewProduct = async (req, res) => {
  const { description, name, price,stock = 0 } = req.body;

  if (description == null || name == null || stock == null || price == null)  {
    return res.status(400).json({ msg: "Campos no pueden ser nulos" });
  }
  if (typeof stock !== 'number') {
    return res.status(400).json({ msg: "Stock mal definido" });
  }

  if (typeof price !== 'number') {
  return res.status(400).json({ msg: "Price mal definido" });
  }


  try {
    const pool = await getConnection();

    const result = await pool
      .request()
      .input("name", sql.VarChar, name)
      .input("description", sql.VarChar, description)
      .input("price", sql.Decimal, price)
      .input("stock", sql.Int, stock)
      .output("message")
      .output("value")
      .execute("SP_CREATE_PRODUCT");

    return res.json({
      data:{
        id:result.output.value
      },
      message: result.output.message
    });
  } catch (error) {
    res.status(500).send(error.Message);
  }
};

export const getProductById = async (req, res) => {
  try {
    const pool = await getConnection();

    const result = await pool
      .request()
      .input("id", req.params.id)
      .execute("SP_READ_PRODUCT");

    return res.json(result.recordset[0]);
  } catch (error) {
    res.status(500).send(error.Message);
    console.log(error);
  }
};

export const deleteProductById = async (req, res) => {
  try {
    const pool = await getConnection();

    const result = await pool
      .request()
      .input("id", req.params.id)
      .output("message")
      .output("value")
      .execute("SP_DELETE_PRODUCT");

    if (result.rowsAffected[0] === 0) return res.sendStatus(404);

    return res.status(200).json({
      message: result.output.message,
      code: result.output.value
    });
    
  } catch (error) {
    res.status(500).send(error.message);
  }
};

export const updateProductById = async (req, res) => {
  const { description, name, price,stock = 0 } = req.body;

  if (description == null || name == null || stock == null || price == null)  {
    return res.status(400).json({ msg: "Campos no pueden ser nulos" });
  }
  if (typeof stock !== 'number') {
    return res.status(400).json({ msg: "Stock mal definido" });
  }

  if (typeof price !== 'number') {
  return res.status(400).json({ msg: "Price mal definido" });
  }

  try {
    const pool = await getConnection();
    const result = await pool
      .request()
      .input("id", req.params.id)
      .input("name", sql.VarChar, name)
      .input("description", sql.VarChar, description)
      .input("price", sql.Decimal, price)
      .input("stock", sql.Int, stock)
      .output("message")
      .output("value")
      .execute("SP_UPDATE_PRODUCT");

    if (result.rowsAffected[0] === 0) return res.sendStatus(404);

    return res.json({ 
      data:
      { 
        name, 
        description, 
        price,
        stock, 
        id: req.params.id, 
      },
      message:result.output.message,
      code:result.output.value
    });

  } catch (error) {
    res.status(500);
    res.send(error.message);
  }
};
