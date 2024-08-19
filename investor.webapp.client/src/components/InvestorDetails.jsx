import { useState, useEffect } from "react";
import { GetAllInvestors } from '../api/InvestorApi';
import { useNavigate } from "react-router-dom";
import moment from 'moment-timezone';
import '../index.css';
import { formatCurrency } from '../Utils/CurrencyFormatter';


const InvestorDetails = () => { 
    const [investor, setInvestor] = useState(null);
    const [error, setError] = useState();
    const navigate = useNavigate();

    useEffect(() => {
        getAllInvestors();
    }, []);

    const getAllInvestors = async () => {
        setError(null);

        try {
            const data = await GetAllInvestors();
            console.log(data);
            setInvestor(data);

            setError(err);
        } catch (e) {
            setError(e);
        }
    }

    return (
        <div className="container">
            <h1>Investors</h1>
            <table role="table" aria-label='investors'>
                <thead>
                    <tr>
                        <th> Id </th>
                        <th> Name </th>
                        <th> Type </th>
                        <th> Date Added</th>
                        <th>Address</th>
                        <th> Total Commitment</th>
                    </tr>
                </thead>
                <tbody>
                    {investor?.map((investor) => (
                        <tr key={investor.id} onClick={() => navigate(`/investor/${investor.id}`)} style={{ cursor: 'pointer' }}>
                            <td>{investor.id}</td>
                            <td>{investor.name}</td>
                            <td>{investor.investorType}</td>
                            <td>{moment(investor.dateAdded).format("MMM DD, yyyy")}</td>
                            <td>{investor.country}</td>
                            <td>{formatCurrency(investor.totalCommitmentAmount)}</td>
                        </tr>
                    ))}
                </tbody>
            </table>
            {error == null && <span>(error)</span>}
        </div>
    );
}

export default InvestorDetails;
