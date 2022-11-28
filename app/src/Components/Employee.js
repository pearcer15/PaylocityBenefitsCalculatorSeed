import React from "react";
import { currencyFormat } from "../Utilities/Constants";
import EditEmployeeModal from "./Modals/EditEmployeeModal";
import DeleteModal from "./Modals/DeleteModal";

class Employee extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            editOpen: false,
            deleteOpen: false,
        };
        this.firstName = this.props.firstName || '';
        this.lastName = this.props.lastName || '';
        this.salary = this.props.salary || 0;    
    }
    openEditModal = () => {
       this.setState({
        editOpen: true
       })
    }

    handleCloseEditModal = () => {
        this.setState({
            editOpen: false
        })
    }

    openDeleteModal = () => {
        this.setState({
            deleteOpen: true
        })
    }

    handleCloseDeleteModal = () => {
        this.setState({
            deleteOpen: false
        })
    }
    
    render(){
    return (
        <tr>
            <th scope="row">{this.props.id}</th>
            <td>{this.lastName}</td>
            <td>{this.firstName}</td>
            <td>{this.props.dateOfBirth}</td>
            <td>
                {currencyFormat(this.salary)}

            </td>
            <td>{this.props.dependents?.length || 0}</td>
            <td>
                <EditEmployeeModal
                data={this.props}
                IsModalOpen={this.state.editOpen}
                onCloseModal={this.handleCloseEditModal}
                />
                  <button type="button" className="btn btn-primary" onClick={this.openEditModal}>Edit</button>
                <DeleteModal
                data={this.props}
                IsModalOpen={this.state.deleteOpen}
                onCloseModal={this.handleCloseDeleteModal}
                />
                  <button type="button" className="btn btn-warn" onClick={this.openDeleteModal}>Delete</button>
            </td>
        </tr>
    );
    }
};

export default Employee;