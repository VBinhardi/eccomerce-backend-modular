-- Habilita extensão para UUID se necessário
CREATE EXTENSION IF NOT EXISTS "pgcrypto";

-- Criação da tabela de pedidos
CREATE TABLE IF NOT EXISTS orders (
    id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    created_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP
);

-- Criação da tabela de itens de pedido
CREATE TABLE IF NOT EXISTS order_items (
    id SERIAL PRIMARY KEY,
    order_id UUID NOT NULL REFERENCES orders(id) ON DELETE CASCADE,
    product_id UUID NOT NULL,
    product_name TEXT NOT NULL,
    quantity INTEGER NOT NULL,
    unit_price INTEGER NOT NULL
);

-- Exemplo de inserção (opcional - seed inicial)
INSERT INTO orders (id, created_at) VALUES
    ('11111111-1111-1111-1111-111111111111', NOW());

INSERT INTO order_items (order_id, product_id, product_name, quantity, unit_price) VALUES
    ('11111111-1111-1111-1111-111111111111', gen_random_uuid(), 'Produto A', 2, 1500),
    ('11111111-1111-1111-1111-111111111111', gen_random_uuid(), 'Produto B', 1, 3000);