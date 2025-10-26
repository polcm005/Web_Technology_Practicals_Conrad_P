function Card(props) {
    return (
        <div className="card" style={{ width: 25 + 'rem'}}>
            <img src={props.itemImage} className="card-img-top" alt={"Image of " + props.itemName} />
            <div className="card-body">
                <h2 className="card-title">{props.itemName}</h2>
                <p className="card-text">{props.itemDescription}</p>
                <p className="card-text">{props.itemCost}</p>
                <a href="#" className="btn btn-primary">button {props.itemId}</a>
                </div>
        </div>
    )
}
export default Card