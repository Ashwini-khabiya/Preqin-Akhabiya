export async function GetAllInvestors() {
    const url = "https://localhost:7235/api/Investor";
    const response = await fetch(url);

    if (!response.ok) {
        throw Error('Error fetching : ${url}');
    }
    return response.json();

}

export async function FetchInvestorDetailsById(id) {
    const url = `https://localhost:7235/api/Investor/${id}`;
    const response = await fetch(url);

    if (!response.ok) {
        throw Error('Error fetching : ${url}');
    }
    return response.json();

}



