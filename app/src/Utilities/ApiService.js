export const baseUrl = 'https://localhost:7124';
export const employeesUrl = '/api/v1/Employees';
export const dependentsUrl = '/api/v1/Dependents';

export const fetchGet = (url) => {
    return fetch(`${baseUrl}${url}`)
    .then((raw) => {return raw.json()})
}

export const fetchDelete = (url) => {
    return fetch(`${baseUrl}${url}`,
    {
        headers: {
            "Access-Control-Allow-Methods": 'DELETE'
        }, 
        method: 'DELETE'
    })
    .then((raw) => {return raw.json()})
}

export const fetchPost = (url, request) => {
    return fetch(`${baseUrl}${url}`,
    {
        headers: {
            'Content-Type': 'application/json',
            "Access-Control-Allow-Methods": 'POST'
        }, 
        method: 'POST',
        body: JSON.stringify(request),
    })
    .then((raw) => {return raw.json()})
}

export const fetchPut = (url, request) => {
    return fetch(`${baseUrl}${url}`,
    {
        headers: {
            'Content-Type': 'application/json',
            "Access-Control-Allow-Methods": 'PUT'
        }, 
        method: 'PUT',
        body: JSON.stringify(request),
    })
    .then((raw) => { return raw.json() })
}

