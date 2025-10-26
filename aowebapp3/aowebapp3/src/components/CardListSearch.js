import React, { useState } from 'react'
import CardV3 from "./CardV3"
// import cardData from "../assets/itemData.json"

const CardListSearch = ({ }) => {

    const [cardData, setState] = useState([]);
    const [query, setQuery] = useState('');

    React.useEffect(() => {
        console.log("useEffect called");
        fetch(`http://localhost:5114/api/ItemsWebAPI?searchText=${query}`)
            .then(response => response.json())
            .then(data => setState(data))
            .catch(err => {
                console.log(err);
            });
    }, [query])

    function searchQuery(evt) {
        const value = document.querySelector('[name="searchText"]').value;
        /*alert('value: ' + value);*/
        setQuery(value);
    }

    return (
        <div id="cardListSearch">
            <div className="row justify-content-start mb-3">
                <div className="col-3">
                    <input type="text" name="searchText" className="form-control" placeholder="Enter search terms..." />
                </div>
                <div className="col text-left">
                    <button type="button" className="btn btn-primary" onClick={searchQuery}>Search</button>
                </div>
            </div>
            <div id="cardList" className="row">
                {cardData.map((obj) => (
                    <CardV3
                        key={obj.itemId}
                        itemID={obj.itemId}
                        itemName={obj.itemName}
                        itemDescription={obj.itemDescription}
                        iteCostm={obj.itemCost}
                        itemImage={obj.itemImage}
                    />
                )
                )
                }
            </div>
        </div>
    )
}

    export default CardListSearch