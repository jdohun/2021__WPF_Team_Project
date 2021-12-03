using System.ComponentModel;

// 프로퍼티의 값을 수정해주는 이벤트 처리기 Notifiler 클래스

public class Notifier : INotifyPropertyChanged {
    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged( string propertyName ) {
        if ( PropertyChanged != null ) {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
