import Modal from 'react-modal';

function AddDependentModal(props) {
    function onModalClose(event) {
        props.onCloseModal(event);
    }

    return (
        <div>
        <Modal
            isOpen={props.IsModalOpen}
            ariaHideApp={false}
        >
            <h1>Add/Edit Dependent</h1>
            <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close" onClick={onModalClose}></button>
            <div>
                {props.data.firstName}
            </div>
            <div className="modal-footer">
                <button type="button" className="btn btn-secondary" data-bs-dismiss="modal" onClick={onModalClose}>Close</button>
                <button type="button" className="btn btn-primary">Save changes</button>
            </div>
        </Modal>
        </div>
    )
}

export default AddDependentModal;