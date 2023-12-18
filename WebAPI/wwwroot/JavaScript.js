// app.js
document.addEventListener('DOMContentLoaded', function () {
    fetchOrders();
});

function fetchOrders() {
    const apiUrl = 'https://your-api-endpoint/api/OrderTbls';
    const orderListElement = document.getElementById('orderList');

    axios.get(apiUrl)
        .then(response => {
            const orders = response.data;
            renderOrders(orders);
        })
        .catch(error => {
            console.error('Error fetching orders:', error);
        });
}

function renderOrders(orders) {
    const orderListElement = document.getElementById('orderList');
    orderListElement.innerHTML = '';

    orders.forEach(order => {
        const listItem = document.createElement('li');
        listItem.textContent = `${order.itemName} - ${order.itemQty}`;
        orderListElement.appendChild(listItem);
    });
}

function placeOrder() {
    const newOrder = getFormData();
    const apiUrl = 'https://your-api-endpoint/api/OrderTbls';

    axios.post(apiUrl, newOrder)
        .then(response => {
            console.log('Order placed successfully:', response.data);
            fetchOrders(); // Refresh the order list after placing a new order
        })
        .catch(error => {
            console.error('Error placing order:', error);
        });
}

function updateOrder() {
    const updatedOrder = getFormData();
    const apiUrl = `https://your-api-endpoint/api/OrderTbls/${updatedOrder.itemCode}`;

    axios.put(apiUrl, updatedOrder)
        .then(response => {
            console.log('Order updated successfully:', response.data);
            fetchOrders(); // Refresh the order list after updating an order
        })
        .catch(error => {
            console.error('Error updating order:', error);
        });
}

function getFormData() {
    return {
        itemCode: 0, // Leave it as 0 for auto-increment
        itemName: document.getElementById('itemName').value,
        itemQty: document.getElementById('itemQty').value,
        orderDelivery: document.getElementById('orderDelivery').value,
        orderAddress: document.getElementById('orderAddress').value,
        phoneNumber: document.getElementById('phoneNumber').value
    };
}