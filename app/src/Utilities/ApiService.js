export const baseUrl = 'https://localhost:7124';
export const employeesUrl = '/api/v1/Employees';
export const dependentsUrl = '/api/v1/Dependents';

// why did i make this all so specific? come back and fix this
export const getEmployees = () => {
    return fetch(`${baseUrl}${employeesUrl}`)
    .then((raw) => {return raw.json()})
}

export const deleteRecord = (isEmployee, id) => {
    fetch(`${baseUrl}${isEmployee ? employeesUrl : dependentsUrl}/${id}`,
    {
        headers: {
            "Access-Control-Allow-Methods": 'DELETE'
        }, 
        method: 'DELETE'
    })
    .then((raw) => raw.json())
    .then((response) => {
        return response;
    })
}

export const addRecord = (isEmployee, newRecord) => {
    fetch(`${baseUrl}${isEmployee ? employeesUrl : dependentsUrl}`,
    {
        headers: {
            'Content-Type': 'application/json',
            "Access-Control-Allow-Methods": 'POST'
        }, 
        method: 'POST',
        body: JSON.stringify(newRecord),
    })
    .then((raw) => raw.json())
    .then((response) => {
        return response;
    })
}

export const editRecord = (isEmployee, updateRecord) => {
    fetch(`${baseUrl}${isEmployee ? employeesUrl : dependentsUrl}/${updateRecord.id}`,
    {
        headers: {
            'Content-Type': 'application/json',
            "Access-Control-Allow-Methods": 'PUT'
        }, 
        method: 'PUT',
        body: JSON.stringify(updateRecord),
    })
    .then((raw) => raw.json())
    .then((response) => {
        return response;
    })
}

