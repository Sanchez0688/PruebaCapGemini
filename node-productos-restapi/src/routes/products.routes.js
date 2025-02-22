import { Router } from "express";
import {
  getProducts,
  createNewProduct,
  getProductById,
  deleteProductById,
  updateProductById,
} from "../controllers/products.controller.js";

const router = Router();

router.get("/products", getProducts);

router.post("/products", createNewProduct);

router.get("/products/:id", getProductById);

router.delete("/products/:id", deleteProductById);

router.put("/products/:id", updateProductById);

export default router;
