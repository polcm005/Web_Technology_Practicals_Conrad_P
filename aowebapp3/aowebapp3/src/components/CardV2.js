function CardV2({ itemId, itemName, itemDescription, itemCost, itemImage}) {
    return (
        <div className="card" style={{ width: 25 + 'rem'}}>
            <img src={itemImage} className="card-img-top" alt={"Image of " + itemName} />
            <div className="card-body">
                <h2 className="card-title">{itemName}</h2>
                <p className="card-text">{itemDescription}</p>
                <p className="card-text">{itemCost}</p>
                <a href="#" className="btn btn-primary">button {itemId}</a>
                </div>
        </div>
    )
}
export default CardV2