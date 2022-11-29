import React from 'react';
import Modal from 'react-modal';
import { dependentsUrl, fetchPut } from '../../Utilities/ApiService';

class AddDependentModal extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            firstName: this.props.data.firstName || '',
            lastName: this.props.data.lastName || '',
            dateOfBirth: this.props.data.dateOfBirth || '2000-01-01',
            relationship: this.props.data.relationship || 1
        }
    }

    onModalClose = (event) => {
        this.props.onCloseModal(event);
    }

    handleChange = (event) => {
        this.setState({
            [event.target.name]: event.target.value
        });
     }

    handleSubmit = () =>  {
        if(this.props.editMode) {
            this.props.onCloseModal(this.editDependent());
        } else{
            this.props.onCloseModal(this.addDependent());
        }
    }

    addDependent = () => {
        return {
            firstName: this.state.firstName,
            lastName: this.state.lastName,
            dateOfBirth: this.state.dateOfBirth,
            relationship: Number(this.state.relationship),
            employeeId: this.props.employeeId,
        };
    }

    editDependent = () => {
        return {
            firstName: this.state.firstName,
            lastName: this.state.lastName,
            dateOfBirth: this.state.dateOfBirth,
            relationship: Number(this.state.relationship),
        };
    }

    render() {
    return (
        <div>
        <Modal
            isOpen={this.props.IsModalOpen}
            ariaHideApp={false}
        >
            <h1>Add/Edit Dependent</h1>
            <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close" onClick={this.onModalClose}></button>
            <div>
            <form>
                    <label>
                        First Name:
                        <input type="text" name="firstName" value={this.state.firstName} onChange={this.handleChange} />
                    </label>
                    <label>
                        Last Name:
                        <input type="text" name="lastName" value={this.state.lastName} onChange={this.handleChange} />
                    </label>
                    <label>
                        Date of Birth:
                        <input type="date" name="dateOfBirth" value={this.state.dateOfBirth} onChange={this.handleChange} />
                    </label>
                    <select name="relationship" value={this.state.relationship} onChange={this.handleChange} >
                        <option value="1">Spouse</option>
                        <option value="2">Domestic Partner</option>
                        <option value="3">Child</option>
                    </select>
            </form>
            </div>
            <div className="modal-footer">
                <button type="button" className="btn btn-secondary" data-bs-dismiss="modal" onClick={this.onModalClose}>Close</button>
                <button type="button" className="btn btn-primary"  onClick={this.handleSubmit}>Save changes</button>
            </div>
        </Modal>
        </div>
    );
    }
}

export default AddDependentModal;