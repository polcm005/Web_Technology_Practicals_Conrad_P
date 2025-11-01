import { useState, useEffect } from "react"
import { Link, useParams } from "react-router-dom";

const CardDetail = ({ }) => {
    let params = useParams();

    const [cardData, setState] = useState({});
    const [itemId, setItemId] = useState(params.itemId);

    useEffect(() => {
        console.log("useEffect called");
        fetch(`http://localhost:5114/api/ItemsWebAPI/${itemId}`)
            .then(response => response.json())
            .then(data => setState(data))
            .catch(err => {
                console.log(err);
            });
    }, [itemId])

    return(
        <div className="card col-4 mb-2" style={{ width: 18 + 'rem' }}>
            <img src={cardData.itemImage} className="card-img-top" alt={"Image of " + cardData.itemName} />
            <div className="card-body">
                <h2 className="card-title">{cardData.itemName}</h2>
                <p className="card-text">{cardData.itemDescription}</p>
                <p className="card-text">{cardData.itemCost}</p>
                <Link to="/Products" className="btn btn-primary">Return to Products</Link>
            </div>
        </div>
    )   
}

export default CardDetail