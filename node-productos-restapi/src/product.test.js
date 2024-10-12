
import app from "./app.js";
import request from 'supertest';


describe('Pruebas de la API de productos', () => {
    test('Actualizar un producto (PUT /products/:id)', async () => {
        const id = 9;
        const producto = {
            name: 'Producto actualizado',
            description: 'Descripción actualizada',
            price: 99.99,
            stock: 50
        };
        const resultProduct= {
            data: producto,
            message: "Producto actualizado exitosamente.",
            "code": 0
        }

        const response = await request(app)
            .put(`/api/products/${id}`)
            .send(producto);
        console.log(response.body.producto);
        expect(response.statusCode).toBe(200);
        expect(response.body).toHaveProperty('message', 'Producto actualizado exitosamente.');
        expect(response.body).toMatchObject(resultProduct);
    });

    test('Eliminar un producto (DELETE /products/:id)', async () => {
        const id = 1;

        const response = await request(app)
            .delete(`/api/products/${id}`);

        expect(response.statusCode).toBe(200);
    });
});
